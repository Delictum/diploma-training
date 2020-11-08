//����������� ���� ����� ���������� �� ������ 
//(�����, ��������, ��� �������, ���������� �������), 
//������� ����� �� ���� ������� � ��������� �������.
type
  rab = record 
    fam1: string[20];
    fam2: string[20];
    zrp1: longint;
    zrp2: longint;
  end;

var
  inp, out: text;
  z: array[1..10] of rab;
  x: rab;
  k, n, i, j, t, c: integer;
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
    readln(inp, z[i].fam1); {��������� � ������}
    writeln(z[i].fam1); {������� � ������� ������}
    readln(inp, z[i].fam2); {��������� � ������}
    writeln(z[i].fam2); {������� � ������� ������}
    readln(inp, s); {��������� ����� ���� string}
    val(s, t, c); {��������� ������ � �����}
    z[i].zrp1 := t; {���������� ����� � ������}
    writeln(z[i].zrp1); {������� �� �����}
    readln(inp, s); {��������� ����� ���� string}
    val(s, t, c); {��������� ������ � �����}
    z[i].zrp2 := t; {���������� ����� � ������}
    writeln(z[i].zrp2); {������� �� �����}
  end;
  close(inp);
  
  for i := 1 to n do
    for j := n downto i do
      if (z[i].zrp1 <= z[j].zrp1) then
      begin              
        x := z[i];
        z[i] := z[j];
        z[j] := x;          
      end;

  for i := 1 to n do
  begin
    writeln(out, z[i].fam1);
    writeln(out, z[i].fam2);
    writeln(out, z[i].zrp1);
    writeln(out, z[i].zrp2);
  end;
  close(out);
  write('� ���� ���������!');
end.