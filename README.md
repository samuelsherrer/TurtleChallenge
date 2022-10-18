

# TurtleChallenge

## Execution

To execute this project, you need to build and specify the config and move files.
There are already two files, for example:

```PowerShell
.\TurtleChallenge.Console.exe game-settings moves
```

## Config File


| Type | Description | Columns | Example
|--|--|--|--|
| Size | Board size | pos x, pos y | Size,4,5
| Start| Start position of the turtle in the board | pos x, pos y, orientation | Start,1,0,North
| Exit | Board exit position to succeed in the game | pos x, pos y | Exit,2,4
| Mine | Mine positions | pos x, pos y | Mine,3,3

---

|Orientation|
|--|
| North |
| East |
| South |
| West|

### Example

```
Size,4,5
Start,1,0,North
Exit,2,4
Mine,1,1
Mine,1,3
Mine,3,3
```

## Move File

|Movement| Id |
|--|--
| Rotate​ 90 degrees to the right | r |
| Move​ one tile forward | m |

 ### Example

```
r,r,m,m
```

 - rotate
 - rotate
 - move
 - move
