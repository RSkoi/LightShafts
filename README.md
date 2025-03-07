# LightShafts

Volumetric Light Shafts for the KK/KKS studio, lazy port of [Light Shafts](https://github.com/robcupisz/LightShafts). Requires [Component Util](https://github.com/RSkoi/ComponentUtil). Light Shafts do not react to Vanilla+ shaders, see **Known Quirks & Issues** below.

Light Shafts are computationally expensive. Try to keep resolutions and sample counts to a minimum.

## How-To-Use

0. Add a `Directional` or `Spot` light to the studio workspace.
1. Select the light and toggle ComponentUtil's UI.
2. Add the `LightShaftsEffect` with the ComponentAdder window to the selected `GameObject`, it has to be next to a `Component` named `Light`.
3. Adjust properties and fields of the `LightShaftsEffect` to your liking.

## Known Quirks & Issues

- Not all shaders are supported, meaning not all objects will be picked up by the Light Shafts. Generally, Light Shafts will only react to Standard-adjacent shaders, such as Unity's built-in Standard or IBL_shader. You can sometimes hack your way around this limitation by duplicating a material, setting the shader to IBL_shader and 'hiding' it behind the original material.
- Light Shafts (their shadow map to be exact) can be made static by setting `m_ShadowmapMode` (Field) to `Static` and toggling `ForceShadowmapDirty` (Property) to true / checked.  This is helpful for when Light Shafts conflict with scripted items, such as mirror surfaces. Notice that recalculation of Light Shafts is only triggered when `ForceShadowmapDirty` is set to true.
