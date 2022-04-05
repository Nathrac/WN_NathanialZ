using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class ShaderModel 
{
    [RealtimeProperty(1, true, true)] private bool _isGlowing;
}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class ShaderModel : RealtimeModel {
    public bool isGlowing {
        get {
            return _isGlowingProperty.value;
        }
        set {
            if (_isGlowingProperty.value == value) return;
            _isGlowingProperty.value = value;
            InvalidateReliableLength();
            FireIsGlowingDidChange(value);
        }
    }
    
    public delegate void PropertyChangedHandler<in T>(ShaderModel model, T value);
    public event PropertyChangedHandler<bool> isGlowingDidChange;
    
    public enum PropertyID : uint {
        IsGlowing = 1,
    }
    
    #region Properties
    
    private ReliableProperty<bool> _isGlowingProperty;
    
    #endregion
    
    public ShaderModel() : base(null) {
        _isGlowingProperty = new ReliableProperty<bool>(1, _isGlowing);
    }
    
    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        _isGlowingProperty.UnsubscribeCallback();
    }
    
    private void FireIsGlowingDidChange(bool value) {
        try {
            isGlowingDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = 0;
        length += _isGlowingProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        var writes = false;
        writes |= _isGlowingProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case (uint) PropertyID.IsGlowing: {
                    changed = _isGlowingProperty.Read(stream, context);
                    if (changed) FireIsGlowingDidChange(isGlowing);
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
        _isGlowing = isGlowing;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */