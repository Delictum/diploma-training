program Est;

var
  s, x: string;
  a, d, i, z: integer;
  g: array['�'..'�'] of integer;
  e: char;

begin
  x := '��������������������';
  readln(s);
  a := length(s);
  for e := '�' to '�' do 
    if pos(e, s) <> 0 then g[e] := g[e] + 1;
  for e := '�' to '�' do
    if (pos(e, x) <> 0) and (d + 1 - g[e] = 1) then write(e, ' ');
end.