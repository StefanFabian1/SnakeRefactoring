using System;

namespace Snake.Game.Core.Interfaces
{
    public interface IConfigProvider
    {
        /// <summary>
        /// Načíta konfiguráciu z externého zdroja
        /// </summary>
        /// <returns>True ak sa konfigurácia načítala úspešne, inak false</returns>
        bool LoadConfig();

        /// <summary>
        /// Uloží aktuálnu konfiguráciu do externého zdroja
        /// </summary>
        /// <returns>True ak sa konfigurácia uložila úspešne, inak false</returns>
        bool SaveConfig();

        /// <summary>
        /// Získa hodnotu z konfigurácie
        /// </summary>
        /// <typeparam name="T">Typ hodnoty</typeparam>
        /// <param name="key">Kľúč hodnoty</param>
        /// <param name="defaultValue">Predvolená hodnota ak kľúč neexistuje</param>
        /// <returns>Hodnota z konfigurácie alebo predvolená hodnota</returns>
        T GetValue<T>(string key, T defaultValue = default);

        /// <summary>
        /// Nastaví hodnotu v konfigurácii
        /// </summary>
        /// <typeparam name="T">Typ hodnoty</typeparam>
        /// <param name="key">Kľúč hodnoty</param>
        /// <param name="value">Hodnota</param>
        void SetValue<T>(string key, T value);
    }
} 