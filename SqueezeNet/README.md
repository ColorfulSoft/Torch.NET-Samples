# Squeezenet

## How to compile

### On Windows

```
> C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /r:%Path_to_SystemAI% /optimize
```

### On Linux using Mono

```
> csc /r:$Path_to_SystemAI /optimize
```

## How to run

### On Windows

```
> Program.exe %Your_image%
```

### On Linux

```
> mono Program.exe $Your_image
```

## Returns

The program will print 5 most probable classes to console.

## Notes

It is assumed that you use CMD on Windows and Bash-like shell on Linux.
