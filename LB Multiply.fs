vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{
	
	
	vec4		adjustedTop = vec4(topAlpha)*top;
	vec4		adjustedBottom = vec4(bottomAlpha)*bottom;
	//adjustedTop.a = 1.0;
	//adjustedBottom.a = 1.0;
	return (adjustedTop*adjustedBottom);
	
	
	
	
	
	/*
	R = Base × Blend
	*/
}


vec4 CompositeBottom(vec4 bottom, float bottomAlpha)	{
	return vec4(0.0, 0.0, 0.0, 0.0);
}
vec4 CompositeTop(vec4 top, float topAlpha)	{
	return vec4(0.0, 0.0, 0.0, 0.0);
}
