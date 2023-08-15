
Func<(int, int), bool> detectZeroOR = (arg) =>
(arg) switch
{
    { Item1: 0, Item2: 0 } => true,
    { Item1: 0 } => true,
    { Item2: 0 } => true,
    _ => false,
};

Func<(int, int), bool> detectZeroOR1 = (arg) =>
(arg) switch
{
    (0, 0) => true,
    (0, _) => true,
    (_, 0) => true,
    _ => false,
};

Func<(int, int), bool> detectZeroOR2 = (arg) =>
arg switch
{
    (var X, var Y) when (X == 0 && Y == 0) || X == 0 || Y == 0 => true,
    _ => false,
};

Func<(int, int), bool> detectZeroOR3 = (arg) =>
(arg is (0, 0) || arg is (0, _) || arg is (_, 0));