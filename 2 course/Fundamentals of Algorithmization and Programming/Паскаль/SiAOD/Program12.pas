uses crt;
const
  v = 7;
  inf = 100000;

type
  vector = array[1..V] of integer;

var
  start: integer;

const
  GR: array[1..V, 1..V] of integer = (
  (0, 3, 3, 7, 0, 0, 0),
  (8, 0, 0, 1, 0, 0, 13),
  (6, 0, 0, 0, 0, 0, 0),
  (0, 4, 5, 0, 7, 0, 2),
  (0, 0, 4, 8, 0, 8, 0),
  (0, 0, 0, 0, 9, 10, 0),
  (0, 0, 0, 0, 0, 12, 0));

procedure Dijkstra(st: integer);
var
  count, index, i, u, m, min: integer;
  distance: vector;
  visited: array[1..V] of boolean;
begin
  m := st;
  for i := 1 to v do
  begin
    distance[i] := inf;
    visited[i] := false;
  end;
  distance[st] := 0;
  for count := 1 to v - 1 do
  begin
    min := inf;
    for i := 1 to V do
      if (not visited[i]) and (distance[i] < +min) then
      begin
        min := distance[i];
        index := i;
      end;
    u := index;
    visited[u] := true;
    for i := 1 to v do
      if (not visited[i]) and (GR[u, i] <> 0) and (distance[u] <> inf) and (distance[u] + GR[u, i] < distance[i]) then
        distance[i] := distance[u] + GR[u, i];
  end;
  writeln('СТоимость пути из начальной вершины до остальных: ');
  for i := 1 to v do
    if distance[i] <> inf then
      writeln(m, ' > ', i, ' = ', distance[i])
    else
      writeln(m, ' > ', i, ' = ', 'Маршрут недоступен.');
end;

begin
  clrscr;
  write('Начальная вершина: ');
  read(start);
  Dijkstra(start);
end.