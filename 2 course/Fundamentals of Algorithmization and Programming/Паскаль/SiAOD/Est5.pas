uses crt;
type
  PNode = ^Node;{��������� �� ����}
  Node = record  {��� ������ � ������� ����� ��������� ����������}
    data: integer;
    left, right: PNode; {������ �� ������ � ������� �������}
  end;

var
  Tree, p1: PNode; {Tree ����� ����� ������, p1-��������������� ����������}
  n, x, i: integer;
  ch: char;{��� ������ �������}

{��������� ���������� �������� }
procedure AddToTree(var Tree: PNode; x: integer);{������� ��������� - ����� ����� ������ � ������ ������� }
begin
  if Tree = nil then  {���� ������ ������ �� ������ ��� ������}
  begin
    New(Tree);   {�������� ������ }
    Tree^.data := x;     {��������� ������ }
    Tree^.left := nil;     {�������� ��������� �� ������ }
    Tree^.right := nil;  {� ������� ������� }
    exit;
  end;
  if x < Tree^.data then   {��� � ������ ��� ������� ��������� ��� ������ �� ��������� ��������}
    AddToTree(Tree^.left, x)  {���� ������ ����� �� � ����� ��������� }
  else
    AddToTree(Tree^.right, x);  {���� ������ �� � ������}
end;

{������� ������ �� ������}
function Search(Tree: PNode; x: integer): PNode;{���������� ����� �������� ��������, nil ���� �� ������}
var
  p: PNode;{������� ����������� }
begin
  if Tree = nil then   {���� ������ ������ ��}
  begin
    Search := nil;  {����������� ������� ��������� ���}
    exit; {� ������� }
  end;
  if x = Tree^.data then  {���� ������� ������� ����� ����� ������ �� }
    p := Tree  {���������� ��� ����� }
     else   {�����}
  if x < Tree^.data then {���� �������� ������� ������ ����� �� }
    p := Search(Tree^.left, x) {�� ���� ��� � ����� ���������}
  else     {����� }
    p := Search(Tree^.right, x);  {���� � ������ ��������� }
  Search := p; {����������� ���������� � ������ ������� ��������� ������}
end;

{����� ������ �� �������� �����-������-������ }
procedure Lkp(Tree: PNode);
begin
  if Tree = nil then  {���� ������ ������ }
    exit;      {�� ����� }
  Lkp(Tree^.right);  {������� ������ ���������}
  write('  ', Tree^.data); {������� ������ }
  Lkp(Tree^.left);  {����� �������� ����� � ������ ���������}
end;

{��������� �������� ������}
procedure DeleteTree(var Tree1: PNode );
begin
  if Tree1 <> nil then
  begin
    DeleteTree(Tree1^.LEFT);
    DeleteTree(Tree1^.RIGHT);
    Dispose(Tree1);
  end;
end;
 {�������� ��������}
begin
  Tree := nil;
  repeat{���� ��� ������ ����}
    
    Writeln('�������� �������� ');
    Textcolor(2);
    Writeln('�������� ��������� ������:');
    Writeln('1) �������� ������ ������');
    Writeln('2) ����� �������� � ������');
    Writeln('3) ����� ������');
    Writeln('4) ������');
    writeln;
    readln(ch); {������� ������� �������}
    case ch of {�������� �������}
      '1':
        begin
          writeln(' kolv elementov');
          readln(n);
          for i := 1 to n do
          begin
            writeln('������� �����');
            readln(x);
            AddToTree(Tree, x);
          end;
        end;
      '2':
        begin
          writeln('������� ��� ������');
          readln(x);
          p1 := Search(Tree, x);
          if p1 <> nil then
            writeln('������')
          else writeln('������ �������� ���!');
        end;
      '3':
        begin
          writeln('���� ������');
          Lkp(Tree);
          writeln;
        end;
    end;
  until ch = '4';
  DeleteTree(Tree);
end.