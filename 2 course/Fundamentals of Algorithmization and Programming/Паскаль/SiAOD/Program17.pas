program kommivoyager_full;

const
  maxv = 100;

var
  { матрица расстояний между городами }
  a: array[1..maxv, 1..maxv]of integer;
  b: array[1..maxv, 1..maxv]of byte;
  way, best: array[1..maxv]of byte;
  
  { был ли коммивояжер в данном городе }
  nnew: array[1..maxv]of boolean; 
  bestcost: integer;
  n, i: integer;

procedure init;
var
  i, j: integer;
begin
  assign(input, '217.in');
  reset(input);
  readln(n);
  for i := 1 to n do
    for j := 1 to n do
      if i = j then 
        a[i, j] := maxint 
      else 
        read(a[i, j]);
  fillchar(nnew, sizeof(nnew), true);
  bestcost := maxint;
end;

{	сортируем каждую строку матрицы А по возрастанию
	расстояний. Однако сами элементы матрицы А не
	переставляем ,а изменяем в матрице B номера столбцов
	матрицы А.}
procedure sortlines;
var
  k, i, j: integer;
  w: integer;
begin
  for i := 1 to n do
    for j := 1 to n do
      b[i, j] := j;
  for k := 1 to n do
    for i := 1 to n - 1 do
      for j := i + 1 to n do
        if a[k, b[k, i]] > a[k, b[k, j]] then
        begin
          w := b[k, i];
          b[k, i] := b[k, j];
          b[k, j] := w;
        end;
end;

procedure solve(v, count: byte; cost: integer);{ основная процедура }
var
  i: integer;
begin
  if cost > bestcost then 
    exit;
  if count = n then
  begin
    cost := cost + a[v, 1];
    way[n] := v;
    if cost < bestcost then
    begin
      bestcost := cost;
      best := way;
    end;
    exit;
  end;
  nnew[v] := false;
  way[count] := v;
  for i := 1 to n do
    if nnew[b[v, i]] then 
      solve(b[v, i], count + 1, cost + a[v, b[v, i]]);
  nnew[v] := true;
end;

begin
  init;
  sortlines;
  solve(1, 1, 0);
  writeln(bestcost:4); { вывод результата }
  for i := 1 to n do 
    write(best[i], ' ');
  writeln;
end.