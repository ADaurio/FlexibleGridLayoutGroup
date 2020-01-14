## Overview

Simple Unity GridLayoutGroup extension to make the default GridLayoutGroup more useful.  Allows users to specify scaling options both horizontally and vertically instead of using pixel counts for cell size.  Scaling options include aspect ratio and both a fixed row and column count.  I'm tired of rewriting variations of this script for every project, so it's here for reuse.  Go nuts.

## Properties

|Property|Description|
|---|---|
|Padding|The padding inside the edges of the layout group.|
|Start Corner|The corner where the first element is located.|
|Start Axis|Which primary axis to place elements along. Horizontal will fill an entire row before a new row is started. Vertical will fill an entire column before a new column is started.|
|Constraint|Constraint the grid to a fixed number of rows or columns to aid the auto layout system.|
|Cell Size - (Only if Constraint is Flexible)|The size to use for each layout element in the group.|
|Spacing |The spacing between the layout elements.|
|Off Axis Scaling - (Only if Constraint is NOT Flexible)|The scaling method used for the groups' unconstrained axis.|
|Off Axis Count - (Only if Off Axis Scaling is Count)|Allows a fixed number of 'unconstrained' axis elements.  Essentially allows you to constain both axis at once, like you'd expect in a table.|
|Off Axis Aspect Ratio - (Only if Off Axis Scaling is AspectRatio)|The size of each unconstrained axis element as a ratio to the constrained axis element size.|

## Usage

Create an Empty GameObject on a Canvas and add the FlexibleGridLayoutGroup component object using "Layout/Flexible Grid Layout Group" in the Editor Add Component menu.
