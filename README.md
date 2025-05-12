# LightShafts

Volumetric Light Shafts for the KK/KKS studio, lazy port of [Light Shafts](https://github.com/robcupisz/LightShafts). Requires [Component Util](https://github.com/RSkoi/ComponentUtil).

Light Shafts are computationally expensive. Try to keep resolutions and sample counts to a minimum.

## How-To-Use

0. Add a `Directional` or `Spot` light to the studio workspace.
1. Select the light and toggle ComponentUtil's UI.
2. Add the `LightShaftsEffect` with the ComponentAdder window to the selected `GameObject`, it has to be next to a `Component` named `Light`.
3. Adjust properties and fields of the `LightShaftsEffect` to your liking.

## Known Quirks & Issues

- Light Shafts support different 'depth' modes. `DepthType` (Property) effectively determines which shaders will 'cast' volumetric shadows. Default behaviour is `Opaque` (e.g. Unity Standard, IBL_shader). `TransparentCutout` will pick up Vanilla+ shaders and other masked transparency shaders. `Transparent` is for most semitransparent shaders. `All` combines all three.
- Light Shafts (their shadow map to be exact) can be made static by setting `m_ShadowmapMode` (Field) to `Static` and toggling `ForceShadowmapDirty` (Property) to true / checked.  This is helpful for when Light Shafts conflict with scripted items, such as mirror surfaces. Notice that recalculation of Light Shafts is only triggered when `ForceShadowmapDirty` is set to true.
