program Est;
var
a:array[1..100,1..100]of longint;
i,j,s,m,n:integer;
begin
s:=0;
write('Введите n: ');
readln(n);
m:=n;
for j:=1 to n do
begin
for i:=1 to n do
begin
a[i,j]:=random(100)-50;
write(a[i,j],' ');
end;
writeln;
end;
for i:=1 to n+1 do
for j:=1 to m-i do
if a[i,j]<0 then
s:=s+sqr(a[i,j]);
writeln('Произведение = ',s);
end.