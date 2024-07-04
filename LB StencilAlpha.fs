vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
        // topAlpha is the top layer opacity, fade out the result accordingly,
        // so the results match what would happen if the layer opacity had
        // already been folded into .a
        // bottomAlpha is the layer opacity, so fade out the resulting matted
        // bottom by that also.
	vec4		returnMe = bottom * vec4(bottomAlpha) * vec4(top.a) * vec4(topAlpha);
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
