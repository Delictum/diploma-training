uses crt;
const nmax=10;
var a:array[1..nmax,1..nmax+1] of real;
    n,i,j,k,imx:integer;
    sm,buf:real;
begin
clrscr;
randomize;
repeat
write('Размер матрицы до ',nmax,' n=');
readln(n);
until n in [1..nmax];
for i:=1 to n do
 begin
  sm:=0;
  for j:=1 to n do
   begin
    a[i,j]:=-5+10*random;
    if a[i,j]<0 then
    sm:=sm+abs(a[i,j]);{считаем сумму модулей отрицательных в строках}
   end;
  a[i,n+1]:=sm;{и пишем в дополнительный столбец}
 end;
writeln('Исходная матрица:');
writeln('Сумма':n*6+8);
for i:=1 to n do
 begin
  for j:=1 to n+1 do
   begin
    if j<=n then write(a[i,j]:6:2)
    else write(a[i,j]:8:2);
   end;
  writeln;
 end;
writeln;
{перестановка строк по возрастанию сумм модулей отрицательных элементов строк
сортировка выбором}
for i:=1 to n-1 do {от первой строки до предпоследней}
 begin
  imx:=i;{выбираем номер максимального элемента в последнем столбце}
  for k:=i+1 to n do {впереди}
  if a[k,n+1]<a[imx,n+1] then imx:=k;{если находим больше, запоминаем}
  for j:=1 to n+1 do{все элемeнты строк}
   begin
    buf:=a[i,j];
    a[i,j]:=a[imx,j];{проверяемой и найденной обмениваем}
    a[imx,j]:=buf;
   end;
 end;
writeln('Строки по возрастанию сумм модулей отрицательных элементов:');
writeln('Сумма':n*6+8);
for i:=1 to n do
 begin
  for j:=1 to n+1 do
   begin
    if j<=n then write(a[i,j]:6:2)
    else write(a[i,j]:8:2);
   end;
  writeln;
 end;
readln
end.