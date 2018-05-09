﻿
using System;
using System.Xml.Serialization;
using UnityEngine;

[Serializable]
public class SystemInfoSerializable
{
    [XmlElement(ElementName = "GPU")]
    public string gpuName = SystemInfo.graphicsDeviceName;

    [XmlElement(ElementName = "Driver")]
    public string driver = SystemInfo.graphicsDeviceVersion;
    
    [XmlElement(ElementName = "CPU")]
    public string cpuName = SystemInfo.processorType;
}