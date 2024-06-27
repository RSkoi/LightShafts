# LightShafts

Volumetric Light Shafts for the KK/KKS studio, lazy port of [Light Shafts](https://github.com/robcupisz/LightShafts). Requires [Component Util](https://github.com/RSkoi/ComponentUtil). Light Shafts do not react to Vanilla+ shaders, see **Known Quirks & Issues** below.

Light Shafts are computationally expensive. Try to keep resolutions and sample counts to a minimum.

Note that releases include zipmod with Unity's built-in Standard shaders which exposes them to [Material Editor](https://github.com/IllusionMods/KK_Plugins?tab=readme-ov-file#materialeditor).

## How-To-Use

0. Add a `Directional` or `Spot` light to the studio workspace.
1. Select the light and toggle ComponentUtil's UI.
2. Add the `LightShaftsEffect` with the ComponentAdder window to the selected `GameObject`, it has to be next to a `Component` named `Light`.
3. Adjust properties and fields of the `LightShaftsEffect` to your liking.

## Known Quirks & Issues

- If you add the effect to a `GameObject` without a `Light`, the effect will auto-add one for you, but ComponentUtil will not keep track of it across scene save / load.
- Not all shaders are supported, meaning not all objects will be picked up by the Light Shafts. Generally, Light Shafts will only react to Standard-adjacent shaders, such as Unity's built-in Standard or IBL_shader. You can sometimes hack your way around this limitation by duplicating a material, setting the shader to Standard and 'hiding' it behind the original material.
