﻿using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class ReadOnlyAttribute : PropertyAttribute
{
	public RuntimeMode Mode = RuntimeMode.Always;
}