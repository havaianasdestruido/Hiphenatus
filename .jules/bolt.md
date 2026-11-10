## 2024-05-24 - C# Array Access Optimization
**Learning:** Extracting a single array read/write into a local variable (e.g., `byte b = arr[i]; arr[i] = (byte)(b - 1)`) does not improve performance or reduce memory lookups compared to `arr[i] = (byte)(arr[i] - 1)`. The C# JIT compiler automatically optimizes both to identical machine code.
**Action:** Avoid micro-optimizing simple read-modify-write array expressions unless it's a complex multi-variable swapping or shared computation logic.

## 2024-05-24 - Expensive Disk I/O in Background Loops
**Learning:** The application contained a background thread loop executing `Directory.GetFiles` on the massive System32 directory every 2 seconds to pick a random executable. This caused significant continuous disk I/O overhead.
**Action:** Cache the results of static or rarely-changing heavy disk operations in static fields when used inside repetitive polling loops.
