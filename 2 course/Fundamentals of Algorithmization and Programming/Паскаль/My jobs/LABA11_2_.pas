program Est;

label back;

type
  
  mas = array[1..10, 1..10] of byte;

var
  A: mas;
  b: mas;
  n, i, j, k, jj,imx, ijx, buf, m: integer;

begin
  write('¬ведите  кол-во строк: ');
  readln(n);
  write('¬ведите кол-во столбцов: ');
  readln(m);
  for i := 1 to n do
    for j := 1 to m do
    begin
      a[i, j] := random(20);
    end;
  for i := 1 to n do
  begin
    for j := 1 to m do
      write(a[i, j]:3);
    writeln;
  end;
  
k:=1;
back:
while n>1 do
begin
for i := 1 to n do
for j := 1 to 1 do
if a[i,j]>b[1,1] then b[1,1]:=a[i,j];
for i := 1 to n do
for j := 1 to 1 do
if a[i,j]=b[1,1] then 
begin
b[1,1]:=a[i,j]
a[i,j]:=a[k,j];
a[k,j]:=b[1,1];
end;
k:=k+1;
goto back;
  end;
  
  writeln('ќтсортированный массив:');
  for i := 1 to n do
  begin
    for j := 1 to m do
      write(a[i, j]:3);
    writeln;
  end;
end.