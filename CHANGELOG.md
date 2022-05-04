# 3.1

Target .NET Standard 2.0 only

# 3.0

Several syntax changes to the grammar:

* [Exponentiation operator `**`](https://github.com/ncalc/ncalc/issues/36)
* [Case insensitive operators and key words (e.g. `AND` or `True`)](https://github.com/ncalc/ncalc/issues/37)
* [Support numbers with trailing dot (e.g. `47.`)](https://github.com/ncalc/ncalc/issues/21)
* [Support for positive sign (e.g. `+5`)](https://github.com/ncalc/ncalc/issues/11)

While these changes in themselves wouldn't introduce compatibility issues with previously valid statements, code that relies on statements with these constructs being invalid would be affected. The grammar also had to be regenerated with a new version of ANTLR with some fixes to it since it was clear that the generated source code had been modified manually. Manual review indicates that the regenerated grammar is identical, but because of both these reasons this is released as a new major version.

* [Bugfix: invalid tokens were skipped silently without any errors](https://github.com/ncalc/ncalc/issues/22). Expressions like `"4711"` would ignore the `"` (since that is not the string character in the NCalc syntax) and parse it as the number `4711`, but now an `EvaluationException` is thrown as for other syntax issues. This may affect existing expressions, but since they were always incorrect and now give an exception rather than silently getting a new value it does not merit a new major release.
* [Major bugfix: long integers are now treated as integers](https://github.com/ncalc/ncalc/issues/18). Previous versions converted them to single-precision floats, which caused data loss on large numbers. Since this affects the results of existing expressions, it requires a new major release.
* [New builtin function `Ln()`](https://github.com/ncalc/ncalc/pull/14)

# 2.0

Initial public release of the .NET Core version.
