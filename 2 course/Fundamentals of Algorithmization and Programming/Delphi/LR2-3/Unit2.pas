unit Unit2;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ComCtrls, StdCtrls, Buttons, ExtCtrls, jpeg, GIFImg, ExtDlgs, Mask,
  MPlayer, Grids;

const g = 50;

type
  TForm2 = class(TForm)
    PageControl1: TPageControl;
    Home: TTabSheet;
    Next: TBitBtn;
    Count: TTabSheet;
    Edit1: TEdit;
    Image1: TImage;
    MaskEdit1: TMaskEdit;
    Figures: TTabSheet;
    Button4: TButton;
    Timer1: TTimer;
    Button3: TButton;
    Button5: TButton;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Edit2: TEdit;
    Button6: TButton;
    Edit3: TEdit;
    Edit4: TEdit;
    Label4: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    Label7: TLabel;
    MediaPlayer1: TMediaPlayer;
    Button8: TButton;
    Button7: TButton;
    Shape1: TShape;
    ComboBox1: TComboBox;
    ComboBox2: TComboBox;
    Button9: TButton;
    Button10: TButton;
    Button11: TButton;
    Button12: TButton;
    StringGrid1: TStringGrid;
    BitBtn2: TBitBtn;
    procedure NextClick(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Edit1KeyPress(Sender: TObject; var Key: Char);
    procedure Button6Click(Sender: TObject);
    procedure Edit2KeyPress(Sender: TObject; var Key: Char);
    procedure Button8Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure ComboBox1Change(Sender: TObject);
    procedure ComboBox2Change(Sender: TObject);
    procedure Button9Click(Sender: TObject);
    procedure Button10Click(Sender: TObject);
    procedure Button11Click(Sender: TObject);
    procedure Button12Click(Sender: TObject);
    procedure BitBtn2Click(Sender: TObject);
    procedure BitBtn1Click(Sender: TObject);
      var
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form2: TForm2;
  uslovie: boolean;

implementation

{$R *.dfm}

procedure TForm2.BitBtn1Click(Sender: TObject);
begin
Form2.Hide;
end;

procedure TForm2.BitBtn2Click(Sender: TObject);
begin
PageControl1.ActivePage := Home;
end;

procedure TForm2.Button10Click(Sender: TObject);
begin
if ( shape1.Height < 150) and( shape1.Width <150) then
begin
shape1.Width:=shape1.Width+15;
shape1.Height:=shape1.Height+15;
end;
end;

procedure TForm2.Button11Click(Sender: TObject);
begin
if ( shape1.Height > 45) and( shape1.Width > 45) then
begin
shape1.Width:=shape1.Width-15;
shape1.Height:=shape1.Height-15;
end;
end;

procedure TForm2.Button12Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 1;
end;

procedure TForm2.Button1Click(Sender: TObject);
begin
 Image1.Picture.LoadFromFile ('G:\a_f1612494.jpg');
end;

procedure TForm2.Button3Click(Sender: TObject);
begin
Timer1.Enabled:=false;
MaskEdit1.Text:= '00:00';
end;

procedure TForm2.Button4Click(Sender: TObject);
begin
Timer1.Enabled:=True;
MaskEdit1.Text:= TimeToStr(Now);
end;

procedure TForm2.Button5Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 2;
end;

procedure TForm2.Button6Click(Sender: TObject);

    var

    a : array[1..g,1..g] of integer; // ������
    sum: integer;    // ����� ���������
    sr:    real;    // �������    ��������������
    i, j, n , m, k: integer;    // ������
    begin

    with StringGrid1 do
  for i:=0 to ColCount-1 do
    Cols[i].Clear;
    sum:=0;
    k:=0;
    n:=StrToInt(edit1.Text);
    m:=StrToInt(edit2.Text);
          for i := 1 to n do
              for j := 1 to m do
          begin
          a[j,i]:=random(10);
          StringGrid1.Cells[j-1, i-1] := IntToStr(A[j,i]);
          sum:=sum+a[j,i];
          inc(k);
          end;
          Edit3.Text:=IntToStr(sum);
          sr:=sum/(k);
          Edit4.Text:=FloatToStr(sr);
    end;

procedure TForm2.Button7Click(Sender: TObject);
begin
MediaPlayer1.FileName := 'G:\music\��������.mp3';
MediaPlayer1.Open;
MediaPlayer1.Play;
end;

procedure TForm2.Button8Click(Sender: TObject);
begin
PageControl1.ActivePageIndex := 0;
end;

procedure TForm2.Button9Click(Sender: TObject);
Var a, b, c:integer;
begin
a:=random(5);
b:=random(3);
case a of
  0:
  begin
    Shape1.Brush.Color:=clred; // �������
  end;
    1:
  begin
    Shape1.Brush.Color:=clyellow; //������
  end;
    2:
  begin
    Shape1.Brush.Color:=clgreen; //�������
  end;
    3:
  begin
    Shape1.Brush.Color:=clblack; //������
  end;
      4:
    begin
    Shape1.Brush.Color:=clWhite;
    end;
end;
  case b of
  0: shape1.Shape:=stEllipse;
  1: shape1.Shape:=stRectangle;
  2: shape1.Shape:=stCircle;
  end;
shape1.Width:=random(100)+50;
shape1.Height:=random(100)+50;
end;

procedure TForm2.ComboBox1Change(Sender: TObject);
var i:integer;
begin
  //����� Shape!
  i:=combobox1.ItemIndex;
  case i of
  0:
  begin
    Shape1.Brush.Color:=clred; // �������
  end;
    1:
  begin
    Shape1.Brush.Color:=clyellow; //������
  end;
    2:
  begin
    Shape1.Brush.Color:=clgreen; //�������
  end;
    3:
  begin
    Shape1.Brush.Color:=clblack; //������
    end;
    4:
    begin
    Shape1.Brush.Color:=clWhite;
  end;
  end;
end;

procedure TForm2.ComboBox2Change(Sender: TObject);
var i:integer;
begin
  i:=combobox2.ItemIndex;
  case i of
  0: shape1.Shape:=stEllipse;
  1: shape1.Shape:=stRectangle;
  2: shape1.Shape:=stCircle;
  end;
end;

procedure TForm2.Edit1KeyPress(Sender: TObject; var Key: Char);
begin
  if not (key in ['0'..'9',#8]) then
    key:=#0;
end;

procedure TForm2.Edit2KeyPress(Sender: TObject; var Key: Char);
begin
  if not (key in ['0'..'9',#8]) then
    key:=#0;
end;

procedure TForm2.NextClick(Sender: TObject);
begin
PageControl1.ActivePageIndex := 1;
end;

end.
