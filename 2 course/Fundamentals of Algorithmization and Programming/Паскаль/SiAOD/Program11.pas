uses crt;
const
  n = 6;

type
  MI = array[1..n, 1..n] of integer;
  MB = array[1..n] of boolean;

var
  i, j, start: integer;
  visited: MB;

const
  GM: MI =    
  ((0, 1, 0, 0, 1, 0),
   (1, 0, 1, 1, 0, 0),
   (0, 1, 0, 1, 0, 1), 
   (0, 1, 1, 0, 1, 1), 
   (1, 0, 0, 1, 0, 0), 
   (0, 0, 1, 1, 0, 0));

procedure BFS(visited: mb; _unit: integer);
var
  queue: array[1..n] of integer;
  count, head, i: integer;
begin
  
  for i := 1 to n do
  begin
    queue[i] := 0;
    count := 0;
    Head := 0;
    count := count + 1;
    queue[count] := _unit;
    visited[_unit] := true;
  end;
  while head < count do
  begin
    Head := Head + 1;
    _unit := queue[head];
    write(_unit, ' ');
    visited[1] := true;
    for i := n downto 1 do
    begin
      if (GM[i, _unit] <> 0) and (not visited[i]) then
      begin
        count := count + 1;
        queue[count] := i;
        visited[i] := true;
        _unit := _unit + 1;
      end;
    end;
    for i := 1 to n do
      if (GM[_unit, i] <> 0) and (not visited[i]) then
      begin
        count := count + 1;
        queue[count] := i;
        visited[i] := true;
        _unit := _unit - 1;
      end;
  end;
end;

begin
  clrscr;
  writeln('Матрица смежности графа: ');
  for i := 1 to n do
  begin
    visited[i] := false;
    for j := 1 to n do
      write(' ', GM[i, j]);
    writeln;
  end;
  start := 1;
  writeln('Начальная вершина - ', start);
  write('Порядок обхода: ');
  BFS(visited, start);
end.