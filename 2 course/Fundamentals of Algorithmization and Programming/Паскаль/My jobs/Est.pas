unit Est;

interface

type
  mas = array[1..5, 1..5] of byte;

procedure Vvod(var mt: mas);
procedure Vyvod(var mt: mas;s: string);
procedure mm(var mt: mas);
implementation

procedure vvod(var mt: mas);
{создаем исходную матрицу}
var
  i, j: integer;
begin
  for i := 1 to 5 do
    for j := 1 to 5 do
     begin
      mt[i, j] := random(100);
      end;
end;

procedure Vyvod(var mt: mas;s: string);
{вывод матриц}
var
  i, j: integer;
begin
  writeln(s);
  for i := 1 to 5 do
  begin
    for j := 1 to 5 do
      write(mt[i, j]:3);
    writeln;
  end;
end;

procedure mm(var mt: mas);
var
  mat:mas;
  matr:mas;
  t, j, i, n1, n2, n3, n4: integer;
begin
  
  mat[1,1] := mt[1,1];
  matr[1,1] := mt[1,1];
  for i := 1 to 5 do
    for j := 1 to 5 do
    begin
      if mt[i, j] < mat[1,1] then 
      begin
        mat[1,1]:=mt[i,j];
        n1 := i;
        n2 := j;
      end;
      if mt[i, j] > matr[1,1] then 
      begin
        matr[1,1]:=mt[i,j];
        n3 := i;
        n4 := j;
      end;
    end;
  t := mt[n1, n2];
  mt[n1, n2] := mt[n3, n4];
  mt[n3, n4] := t;
end;
end.