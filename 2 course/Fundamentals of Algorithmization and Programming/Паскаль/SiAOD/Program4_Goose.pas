type
{�������� ������ ���� ������ (����).}
TData = Integer;
{��������� �� ����.}
TPNode = ^TNode;
{���� ������.}
TNode = record
Data : TData; {�������� ������ ���� ������ (����).}
PLeft, PRight : TPNode; {��������� �� ����� � ������ ����.}
end;

{����������� ��������� ��� ������������ ������, ������� �������. (�������� ������).}
procedure TreeFree(var aPNode : TPNode);
begin
if aPNode = nil then Exit;

if aPNode^.PLeft <> nil then TreeFree(aPNode^.PLeft);
if aPNode^.PRight <> nil then TreeFree(aPNode^.PRight);
Dispose(aPNode);
aPNode := nil;
end;

{����������� ������� ������ ������� ��������, ���� ���������� ����, ����
������ �� ������.
������� ���������� ��������:
True - ���� �� ��������� aData �������� � ������, ������ �� ������.
False - ������ �������� ��� ���������, ������ ������.}
function Add(var aPNode : TPNode; const aData : TData) : Boolean;
begin
if aPNode = nil then begin
New(aPNode);
aPNode^.Data := aData;
aPNode^.PLeft := nil;
aPNode^.PRight := nil;
Add := True;
end else if aData < aPNode^.Data then
Add := Add(aPNode^.PLeft, aData)
else if aData > aPNode^.Data then
Add := Add(aPNode^.PRight, aData)
else
Add := False;
end;

procedure Lkp(var aPNode : TPNode);
begin
  if aPNode = nil then  {���� ������ ������ }
    exit;      {�� ����� }
  Lkp(aPNode^.Pright);  {������� ������ ���������}
  write('  ', aPNode^.data); {������� ������ }
  Lkp(aPNode^.Pleft);  {����� �������� ����� � ������ ���������}
end;

var
PTree : TPNode;
Data : TData;
Cmd, Code : Integer;
S : String;
begin
{��������� ������������� ������.}
PTree := nil;

repeat
{����.}
Writeln('�������� ��������:');
Writeln('1: ���������� ������ � ����� ��������.');
Writeln('2: ��������� ������ �� �������.');
Writeln('3: ������� ������.');
Writeln('4: ����� ������.');
Writeln('5: �����.');
Write('������� �������: ');
Readln(Cmd);
case Cmd of
1:
begin
Writeln('���������� ������ � ����� ��������.');
repeat
Write('������� ���� (�������� ���� - ������ ������ + Enter): ');
Readln(S);
if S <> '' then
 begin {���� ������������ ��� �������� ������.}
   Val(S, Data, Code);
   if Code <> 0 then {���� ����� ������� �����������.}
     Writeln('�������� ����. ���������.')
   else 
   begin {���� ����� ������ ���������.}
     if Add(PTree, Data) then {���� �������� ���� (������ ������ �� ������).}
       Writeln('������ �� ������. ���� �������� � ������.')
     else {���� ���� �� ��� �������� (������ ������ ������).}
       Writeln('!!! ������ ������. ������ �������� ��� ���������.');
     Code := 1; {=1 - ����� ���������� ���� ������ � �������.}
   end;
 end 
 else 
  begin {���� ������������ ��� ������ ������.}
    Writeln('������.');
    Code := 0; {�������� ���, ����� ����� �� ����� ������ � �������.}
  end;
until Code = 0;
end;
4:
        begin
          writeln('���� ������');
          Lkp(PTree);
          writeln;
        end;
2:
if PTree <> nil then
Writeln('������ �� ������.')
else
Writeln('������ ������.');
3, 5:
begin
TreeFree(PTree);
Writeln('������ �������.');
end;
else
Writeln('�������������������� �������. ��������� ����.');
end;
until Cmd = 5;

Writeln('������ ��������� ���������. ��� ������ ������� Enter.');
Readln;
end.