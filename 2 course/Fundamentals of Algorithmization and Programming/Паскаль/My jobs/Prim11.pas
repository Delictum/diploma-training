uses crt;
const nmax=10;
var a:array[1..nmax,1..nmax+1] of real;
    n,i,j,k,imx:integer;
    sm,buf:real;
begin
clrscr;
randomize;
repeat
write('������ ������� �� ',nmax,' n=');
readln(n);
until n in [1..nmax];
for i:=1 to n do
 begin
  sm:=0;
  for j:=1 to n do
   begin
    a[i,j]:=-5+10*random;
    if a[i,j]<0 then
    sm:=sm+abs(a[i,j]);{������� ����� ������� ������������� � �������}
   end;
  a[i,n+1]:=sm;{� ����� � �������������� �������}
 end;
writeln('�������� �������:');
writeln('�����':n*6+8);
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
{������������ ����� �� ����������� ���� ������� ������������� ��������� �����
���������� �������}
for i:=1 to n-1 do {�� ������ ������ �� �������������}
 begin
  imx:=i;{�������� ����� ������������� �������� � ��������� �������}
  for k:=i+1 to n do {�������}
  if a[k,n+1]<a[imx,n+1] then imx:=k;{���� ������� ������, ����������}
  for j:=1 to n+1 do{��� ����e��� �����}
   begin
    buf:=a[i,j];
    a[i,j]:=a[imx,j];{����������� � ��������� ����������}
    a[imx,j]:=buf;
   end;
 end;
writeln('������ �� ����������� ���� ������� ������������� ���������:');
writeln('�����':n*6+8);
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