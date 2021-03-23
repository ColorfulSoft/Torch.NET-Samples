# Squeezenet

## How to compile

### On Windows

```
> C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /r:%Path to System.AI% /optimize
```

### On Linux using Mono

```
> csc /r:%Path to System.AI% /optimize
```

## How to run

### On Windows

```
> Program.exe %Your image%
```

### On Linux

```
> mono Program.exe %Your image%
```

## Returns

The program will print 5 most probable classes to console.
