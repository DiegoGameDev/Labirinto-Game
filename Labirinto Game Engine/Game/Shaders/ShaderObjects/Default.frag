#version 400 core
out vec4 FragColor;

in vec2 outPutTexture;

uniform sampler2D texture0;

void main()
{
	FragColor = texture(texture0, outPutTexture);
}