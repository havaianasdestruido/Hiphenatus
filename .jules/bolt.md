## 2025-03-05 - Performance Optimization in Shader Inner Loops
**Learning:** Found significant redundant math operations (e.g., `Math.Sin(ok)` and repeated identical array indexing and trigonometry) nested deep inside `Parallel.For` loops running on every pixel frame in `Hiphenatus/Form1.cs`.
**Action:** Always look for loop-invariant mathematical calculations to hoist outside the loop body, especially in tight inner loops rendering visuals where every instruction counts.
## 2025-02-12 - GDI Shader Math Operations
**Learning:** Legacy GDI-based malware/visual effects often use `Parallel.For` to process massive pixel arrays every single frame. Performing expensive math operations (like `Math.Sqrt`) on byte-sized color values within these tight loops creates massive overhead (millions of operations per frame).
**Action:** Always check if mathematical operations within per-pixel loops have constrained inputs (e.g., 0-255). If they do, precompute the results into a lookup table outside the loop to replace expensive CPU math with O(1) array accesses, significantly boosting frame generation speed.
