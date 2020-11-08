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
assign(inp, 'input.txt'); {устанавливаем св€зь файловой переменной с физическим файлом на диске}
reset(inp);
assign(out, 'output.txt');
rewrite(out); {открываем файл дл€ записи}
read(inp, n); {считываем кол-во данных строк из файла}
writeln(n); {выводим строки в паскаль}
readln(inp, s); {считываем последовательно текст строк из файла}
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
write('Ф ‘айл переписан!');
end.