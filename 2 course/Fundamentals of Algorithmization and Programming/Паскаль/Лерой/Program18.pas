{��������� �������� ��������� ���������� � �����:
Const  Nominal: array[0..10] of currency= (5000, 1000, 500, 100, 50, 10, 5, 1, 0.5, 0.1);  ,
����������������� "������" �������� ������������ �������� ����� ��������. ����� ����� ����� � ����� � ����� ������ ���������� �����������. 
������������ ������-������ � �������� ��� ��������� ������������� ������� ��������� � ����� � ������ � ��������� ����������� ���������� ���������� ���� ��� ����� ��������.}
const
  many: array [1..10] of Real = (5000, 1000, 500, 100, 50, 10, 5, 1, 0.5, 0.1);// ������������ �����

var
  in_kol: array [1..10] of Real; // ����������  �������� �����
  out_kol: array [1..10] of Real;// ���������� ����������� �����
  startsum, sum, tmp: Real;
  s: string;

begin
  // ������� �������
  for var i := 1 to 10 do
  begin
    in_kol[i] := 0;
    out_kol[i] := 0;
  end;
  // ����� ��� ������
  write('������� ����� ��� ������ �����: ');
  readln(sum);
  startsum := sum;
  // ���� ���������� ����� � ������� �� ������������
  for var i := 1 to 10 do
  begin
    write('����� ������������ ', many[i], ' = ');
    readln(in_kol[i]);
  end;
  tmp := 0;
  //
  for var i := 1 to 10 do
  begin
    // ���� ����� ����� ��� ��� ������ ������ ����� - ����������
    if (many[i] > sum) or (in_kol[i] <= 0) then
      continue;
    tmp := Trunc (sum / many[i]);
    // �������� �� ���������� ����� � �� ������
    if tmp <= in_kol[i] then out_kol[i] := tmp
    else out_kol[i] := in_kol[i];
    // ������������� ����� �������� �������� �����
    in_kol[i] := in_kol[i] - out_kol[i];
    // ��������� ����� �� ����� �������� �����
    sum := sum - (out_kol[i] * many[i]);
    // ����� ������ ������� ����� ��������� ������ - �����
    if sum = 0 then break;
  end;
  // �������
  s := ' ������: '#13#10;
  for var i := 1 to 10 do
    if out_kol[i] <> 0 then
      s := s + '������ �� ' + FloatToStr(many[i]) + ' � ���������� ' + FloatToStr(out_kol[i]) + ' ��.' + #13#10;
  if sum <> 0 then 
    writeln('�� �������� ������ �������� �����. ������ ��� ' + #13#10 + s)
  else writeln(s);
  writeln('����� ������: ', (startsum - sum), '!');
end.