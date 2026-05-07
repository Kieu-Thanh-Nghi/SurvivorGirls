void VAT_float(
    float3 PositionOS,
    float2 UV2,
    UnityTexture2D PosTex,
    float Frame,
    float TotalFrames,
    out float3 OutPosition
)
{
    float vertexIndex = UV2.x;

    float frameA = floor(Frame);
    float frameB = fmod(frameA + 1, TotalFrames);
    float t = frac(Frame);

    float invFrames = 1.0 / (TotalFrames - 1);

    float2 uvA = float2(vertexIndex, frameA * invFrames);
    float2 uvB = float2(vertexIndex, frameB * invFrames);

    float3 posA = SAMPLE_TEXTURE2D_LOD(PosTex, PosTex.samplerstate, uvA, 0).xyz;
    float3 posB = SAMPLE_TEXTURE2D_LOD(PosTex, PosTex.samplerstate, uvB, 0).xyz;

    OutPosition = lerp(posA, posB, t);
}