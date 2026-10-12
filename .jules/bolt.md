## 2025-02-18 - [Math.Sqrt Overhead in Pixel Shaders]
**Learning:** [Pixel processing loops frequently duplicated identical expensive math operations (Math.Sqrt) across R, G, B channels, resulting in a 3x penalty for calculations that evaluate to the same value.]
**Action:** [Always extract loop-invariant calculations and common sub-expressions in tight graphics loops, and reuse index variables (e.g. i * 3) instead of recalculating.]
