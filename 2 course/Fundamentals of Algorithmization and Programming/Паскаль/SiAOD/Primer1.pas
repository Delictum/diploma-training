program spisok;

type
  name = string[10];
  ukaz = ^element;
  element = record
    uk: ukaz;
    dan: name
  end;

var
  kniga: name;
  nach, tek, ob, obpr: ukaz;
  i: integer;

begin{ ������������ 1-�� �������� ������ }
  New(nach);
  ReadLn;
  WriteLn('������� ������ ��������');
  Read(kniga);
  nach^.uk := nil;
  nach^.dan := kniga;
  while kniga <> '���' do { ������������ ������ } 
  begin
    tek := nach;
    New(ob);
    WriteLn(' ������� ��������� �������� ');
    Read(kniga);
    while (tek <> nil) and (tek^.dan < kniga) do { ����� ����������� ����� }
    begin
      obpr := tek; { ������ �� ���������� ������� }
      tek := tek^.uk{ ������� � ���������� �������� }
    end;
    {������� ������ �������� }
    ob^.uk := tek;
    ob^.dan := kniga;
    if tek = nach then nach := ob
    Else
      obpr^.uk := ob
  end; { ����� ������������ ������ }
  WriteLn(' ������� ���������:'); { ����� �� ����� ������� �������������� �������� ���� }
  tek := nach;
  while tek^.uk <> nil do 
  begin
    WriteLn(tek^.dan);tek := tek^.uk
  end
end.