﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable disable

namespace System.Windows.Forms.Tests;

// NB: doesn't require thread affinity
public class ListViewVirtualItemsSelectionRangeChangedEventArgsTests
{
    [Theory]
    [InlineData(-2, -2, true)]
    [InlineData(-1, -1, false)]
    [InlineData(0, 0, true)]
    [InlineData(1, 2, true)]
    [InlineData(1, 1, false)]
    public void Ctor_Int_Int_Bool(int startIndex, int endIndex, bool isSelected)
    {
        ListViewVirtualItemsSelectionRangeChangedEventArgs e = new(startIndex, endIndex, isSelected);
        Assert.Equal(startIndex, e.StartIndex);
        Assert.Equal(endIndex, e.EndIndex);
        Assert.Equal(isSelected, e.IsSelected);
    }

    [Fact]
    public void Ctor_StartIndexGreaterThanEndIndex_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new ListViewVirtualItemsSelectionRangeChangedEventArgs(1, 0, false));
    }
}
