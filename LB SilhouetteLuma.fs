vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
        // Use .a as part of the luma calculation to reflect the luma as
        // observed. An asset with transparent sections might have any
        // arbitrary rbg values for the fully transparent pixels, and those
        // invisible color values shouldn't cause unexpected results in the
        // resulting matte. For instance, an asset may have all-white rbg
        // values with a used to carve it into a shape. Ignoring a would result
        // in a solid frame.
        // topAlpha is folded into topLuma so that the lower the opacity of the
        // top layer, the less it 'cuts into' the bottom. This matches After
        // Effects behaviour.
        float           topLuma = top.a * (top.r + top.g + top.b) / 3.0 * topAlpha;
	vec4		returnMe = bottom * vec4(bottomAlpha) * (1.0 - vec4(topLuma));
	return returnMe;
}


// This is used for the case the the bottom layer 'stick out' beyond the bounds of the top?
// Empirically, no. Areas outside the bounds of the top layer don't pass through the shader at all.
vec4 CompositeBottom(vec4 bottom, float bottomAlpha)	{
	vec4		returnMe = vec4(bottomAlpha)*bottom;
	returnMe.a = 1.0;
	return returnMe;
}

// Photoshop never displays the top, even when bottom is missing. We do.
vec4 CompositeTop(vec4 top, float topAlpha)	{
	vec4		returnMe = vec4(topAlpha)*top;
	returnMe.a = 1.0;
	return returnMe;
}
