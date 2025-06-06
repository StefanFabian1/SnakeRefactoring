using System;
using System.IO;
using System.Text.Json;
using Snake.Game.Core.Interfaces;

namespace Snake.Game.Core.Impl
{
    public class JsonConfigProvider : IConfigProvider
    {
        private readonly string _configPath;
        private JsonDocument? _config;

        public JsonConfigProvider(string configPath)
        {
            _configPath = configPath ?? throw new ArgumentNullException(nameof(configPath));
        }

        public bool LoadConfig()
        {
            try
            {
                if (!File.Exists(_configPath))
                {
                    return false;
                }

                string jsonString = File.ReadAllText(_configPath);
                _config = JsonDocument.Parse(jsonString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveConfig()
        {
            try
            {
                if (_config == null)
                {
                    return false;
                }

                string jsonString = _config.RootElement.GetRawText();
                File.WriteAllText(_configPath, jsonString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T GetValue<T>(string key, T defaultValue = default)
        {
            try
            {
                if (_config == null)
                {
                    return defaultValue;
                }

                var element = _config.RootElement.GetProperty(key);
                return JsonSerializer.Deserialize<T>(element.GetRawText()) ?? defaultValue;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public void SetValue<T>(string key, T value)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(value, options);
                
                using var doc = JsonDocument.Parse(jsonString);
                var newConfig = new Dictionary<string, JsonElement>();
                
                if (_config != null)
                {
                    foreach (var property in _config.RootElement.EnumerateObject())
                    {
                        if (property.Name != key)
                        {
                            newConfig[property.Name] = property.Value;
                        }
                    }
                }
                
                newConfig[key] = doc.RootElement;
                _config = JsonDocument.Parse(JsonSerializer.Serialize(newConfig, options));
            }
            catch (Exception)
            {
                // Log error
            }
        }
    }
} 