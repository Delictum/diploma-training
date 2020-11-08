program Est;

var
  s, x: string;
  a, d, i, z: integer;
  g: array['א'..'ÿ'] of integer;
  e: char;

begin
  x := 'בגדהזחךכלםןנסעפץצקרש';
  readln(s);
  a := length(s);
  for e := 'א' to 'ÿ' do 
    if pos(e, s) <> 0 then g[e] := g[e] + 1;
  for e := 'א' to 'ÿ' do
    if (pos(e, x) <> 0) and (d + 1 - g[e] = 1) then write(e, ' ');
end.