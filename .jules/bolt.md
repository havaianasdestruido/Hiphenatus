## 2025-03-05 - Performance Optimization in Shader Inner Loops
**Learning:** Found significant redundant math operations (e.g., `Math.Sin(ok)` and repeated identical array indexing and trigonometry) nested deep inside `Parallel.For` loops running on every pixel frame in `Hiphenatus/Form1.cs`.
**Action:** Always look for loop-invariant mathematical calculations to hoist outside the loop body, especially in tight inner loops rendering visuals where every instruction counts.
