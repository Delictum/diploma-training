unit Kon;

interface

type
  mas = array[1..4, 1..4] of byte;

procedure Vvod(var mt: mas);
procedure Vyvod(var mt: mas;s: string);
implementation

procedure vvod(var mt: mas);
{создаем исходную матрицу}
var
  i, j: integer;
begin
  for i := 1 to 4 do
    for j := 1 to 4 do
    begin
    if (i+j=5) then mt[i, j] := 1;
      end;
end;

procedure Vyvod(var mt: mas;s: string);
{вывод матриц}
var
  i, j: integer;
begin
  writeln(s);
  for i := 1 to 4 do
  begin
    for j := 1 to 4 do
      write(mt[i, j]:3);
    writeln;
  end;
end;

end.