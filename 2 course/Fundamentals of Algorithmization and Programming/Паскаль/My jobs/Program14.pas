type
rab = record 
fam: string[20];
zrp: longint;
end;

var
inp, out: text;
z: array[1..10] of rab;
w: array[1..10] of rab;
x: rab;
k, l, n, i, j, t, c: integer;
s: string;

begin
assign(inp, 'input.txt'); {������������� ����� �������� ���������� � ���������� ������ �� �����}
reset(inp);
assign(out, 'output.txt');
rewrite(out); {��������� ���� ��� ������}
read(inp, n); {��������� ���-�� ������ ����� �� �����}
writeln(n); {������� ������ � �������}
readln(inp, s); {��������� ��������������� ����� ����� �� �����}
for i := 1 to n do
begin
readln(inp, z[i].fam); 
writeln(z[i].fam);
readln(inp, s);
val(s, t, c);
z[i].zrp := t;
writeln(z[i].zrp);
end;
close(inp);
for i := 1 to n - 1 do
for j := i + 1 to n do
if z[i].fam > z[j].fam then
begin
x := z[i];
z[i] := z[j];
z[j] := x;
end;
for i := 1 to n do
  if z[i].zrp>w[1].zrp then
   begin
    w[2].zrp:=w[1].zrp;
    w[1].zrp:=z[i].zrp;
    k:=i;
   end
  else if(z[i].zrp>w[2].zrp)and(z[i].zrp<=w[1].zrp) then 
  begin w[2].zrp:=z[i].zrp;
  l:=i;
  end;
writeln(out, z[k].fam);
writeln(out, w[1].zrp);
writeln(out, z[l].fam);
writeln(out, w[2].zrp);
close(out);
write('� ���� ���������!');
end.