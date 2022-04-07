using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime.Serialization;
using Normal.Realtime;


[RealtimeModel]
public partial class HealthBarModel
{
    [RealtimeProperty(1, true, true)] int _health;
    [RealtimeProperty(2, true, false)] RealtimeDictionary<PlayerDataModel> _players;
}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class HealthBarModel : RealtimeModel {
    public int health {
        get {
            return _healthProperty.value;
        }
        set {
            if (_healthProperty.value == value) return;
            _healthProperty.value = value;
            InvalidateReliableLength();
            FireHealthDidChange(value);
        }
    }
    
    public Normal.Realtime.Serialization.RealtimeDictionary<PlayerDataModel> players {
        get => _players;
    }
    
    public delegate void PropertyChangedHandler<in T>(HealthBarModel model, T value);
    public event PropertyChangedHandler<int> healthDidChange;
    
    public enum PropertyID : uint {
        Health = 1,
        Players = 2,
    }
    
    #region Properties
    
    private ReliableProperty<int> _healthProperty;
    
    private ModelProperty<Normal.Realtime.Serialization.RealtimeDictionary<PlayerDataModel>> _playersProperty;
    
    #endregion
    
    public HealthBarModel() : base(null) {
        RealtimeModel[] childModels = new RealtimeModel[1];
        
        _players = new Normal.Realtime.Serialization.RealtimeDictionary<PlayerDataModel>();
        childModels[0] = _players;
        
        SetChildren(childModels);
        
        _healthProperty = new ReliableProperty<int>(1, _health);
        _playersProperty = new ModelProperty<Normal.Realtime.Serialization.RealtimeDictionary<PlayerDataModel>>(2, _players);
    }
    
    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        _healthProperty.UnsubscribeCallback();
    }
    
    private void FireHealthDidChange(int value) {
        try {
            healthDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = 0;
        length += _healthProperty.WriteLength(context);
        length += _playersProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        var writes = false;
        writes |= _healthProperty.Write(stream, context);
        writes |= _playersProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case (uint) PropertyID.Health: {
                    changed = _healthProperty.Read(stream, context);
                    if (changed) FireHealthDidChange(health);
                    break;
                }
                case (uint) PropertyID.Players: {
                    changed = _playersProperty.Read(stream, context);
                    break;
                }
                default: {
                    stream.SkipProperty();
                    break;
                }
            }
            anyPropertiesChanged |= changed;
        }
        if (anyPropertiesChanged) {
            UpdateBackingFields();
        }
    }
    
    private void UpdateBackingFields() {
        _health = health;
        _players = players;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */
