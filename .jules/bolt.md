## 2025-02-18 - [Math.Sqrt Overhead in Pixel Shaders]
**Learning:** [Pixel processing loops frequently duplicated identical expensive math operations (Math.Sqrt) across R, G, B channels, resulting in a 3x penalty for calculations that evaluate to the same value.]
**Action:** [Always extract loop-invariant calculations and common sub-expressions in tight graphics loops, and reuse index variables (e.g. i * 3) instead of recalculating.]

## 2025-02-14 - Precomputing static Math functions for screen-height dependent rendering
**Learning:** In visual payload screens (e.g. Sines rendering effect), mathematical functions applied to the screen coordinates (`y`) don't need to be calculated repeatedly for every frame because the screen height doesn't change during the payload's runtime. We had over 1000 calls to Math.Tan() per frame inside an inner loop.
**Action:** When calculating effects based on coordinates, precompute coordinate-based formulas into an array before the continuous render loop, and hoist loop-invariant math calculations (like time-based formulas `t`) to the outer loop scope.
