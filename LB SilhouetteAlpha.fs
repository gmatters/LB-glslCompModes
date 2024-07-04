vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
        // topAlpha is folded into top's total alphaness so that the lower the opacity of the
        // top layer, the less it 'cuts into' the bottom. This matches After
        // Effects behaviour.
        float           topValue = top.a * topAlpha;
	vec4		returnMe = bottom * vec4(bottomAlpha) * (1.0 - vec4(topValue));
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
