program Est;

var
  i, j: integer;
  s: real;

begin
for i:=10 to 99 do
if (i div 10 + i mod 10) mod 13=0 then write(i:3);
end.