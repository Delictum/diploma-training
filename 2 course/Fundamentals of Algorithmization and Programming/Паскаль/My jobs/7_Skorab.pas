type
  mas = array [1..99] of integer;

var
  a: mas;
  s, z, k, p: integer;

function ff(af: mas; zf, kf, pf: integer): integer;
begin
  for kf := 1 to pf do
    if af[kf] < 0 then zf := 1 + zf;
    ff:=zf;
end;

function gg(ag: mas; sg, kg, pg: integer): integer;
begin
  for kg := 1 to pg do
    if ag[kg] > 0 then sg := sg + 1;
    gg:=sg;
end;

begin
  write('Введите P: ');
  readln(p);
  for k := 1 to p do 
  begin
    a[k] := random(20)-10;
    writeln(a[k]);
  end;   
    writeln('Количество отрицательных: ', ff(a, z, k, p));
    writeln('Количество положительных: ', gg(a, s, k, p));
end.