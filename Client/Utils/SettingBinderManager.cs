using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ToSic.Cre8magic.Theme.Basic;

internal class SettingBinderManager
{
    public ConcurrentDictionary<string, SettingBinder> Binders { get; } = new();

    // Create an indexer to access binders by setting name
    public SettingBinder this[string settingName]
        => GetOrCreateBinder(settingName);

    private SettingBinder GetOrCreateBinder(string settingName)
    {
        if (Binders.TryGetValue(settingName, out var binder))
            return binder;
        
        
        try
        {
            return Binders.GetOrAdd(Constants.KeyPrefix + settingName, newName => new(null, newName));
        }
        catch
        {
            // If the key already exists, we can just return the existing binder
            throw;
        }

    }

    public void SetEditor(SettingsEditor editor)
    {
        foreach (var binder in Binders.Values)
            binder.Editor = editor;
    }
}