unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ComCtrls, Vcl.ExtCtrls,
  Vcl.Buttons, Vcl.Imaging.jpeg;

type
  TForm1 = class(TForm)
    PageControl1: TPageControl;
    TabSheet2: TTabSheet;
    TabSheet1: TTabSheet;
    TabSheet3: TTabSheet;
    TabSheet4: TTabSheet;
    TabSheet5: TTabSheet;
    TabSheet6: TTabSheet;
    TabSheet7: TTabSheet;
    TabSheet8: TTabSheet;
    TabSheet9: TTabSheet;
    TabSheet10: TTabSheet;
    TabSheet11: TTabSheet;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Label1: TLabel;
    Image1: TImage;
    Image2: TImage;
    Image3: TImage;
    Image4: TImage;
    Label2: TLabel;
    Label3: TLabel;
    SpeedButton1: TSpeedButton;
    SpeedButton2: TSpeedButton;
    SpeedButton3: TSpeedButton;
    SpeedButton4: TSpeedButton;
    SpeedButton5: TSpeedButton;
    SpeedButton6: TSpeedButton;
    SpeedButton7: TSpeedButton;
    SpeedButton8: TSpeedButton;
    SpeedButton9: TSpeedButton;
    SpeedButton10: TSpeedButton;
    RadioButton1: TRadioButton;
    RadioButton2: TRadioButton;
    RadioButton3: TRadioButton;
    RadioButton4: TRadioButton;
    Result: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    CheckBox1: TCheckBox;
    CheckBox2: TCheckBox;
    CheckBox3: TCheckBox;
    CheckBox4: TCheckBox;
    Label6: TLabel;
    Edit1: TEdit;
    Label7: TLabel;
    Label8: TLabel;
    Label9: TLabel;
    ComboBox1: TComboBox;
    TrackBar1: TTrackBar;
    Shape1: TShape;
    Memo1: TMemo;
    Label10: TLabel;
    MonthCalendar1: TMonthCalendar;
    Label11: TLabel;
    Label12: TLabel;
    Label13: TLabel;
    Label14: TLabel;
    Label15: TLabel;
    Label16: TLabel;
    Button5: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Image3Click(Sender: TObject);
    procedure SpeedButton1Click(Sender: TObject);
    procedure SpeedButton2Click(Sender: TObject);
    procedure Image2Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure SpeedButton3Click(Sender: TObject);
    procedure SpeedButton10Click(Sender: TObject);
    procedure SpeedButton4Click(Sender: TObject);
    procedure SpeedButton5Click(Sender: TObject);
    procedure SpeedButton6Click(Sender: TObject);
    procedure TrackBar1Change(Sender: TObject);
    procedure SpeedButton7Click(Sender: TObject);
    procedure SpeedButton8Click(Sender: TObject);
    procedure SpeedButton9Click(Sender: TObject);
    procedure Label15Click(Sender: TObject);
    procedure Label16Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  ball : integer;
  qw1, qw2, qw10 : boolean;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
begin
  qw2 := true;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
  qw2 := false;
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
  PageControl1.ActivePageIndex := 0;
  ball := 0;
end;

procedure TForm1.Image2Click(Sender: TObject);
begin
  qw1 := false;
end;

procedure TForm1.Image3Click(Sender: TObject);
begin
  qw1 := true;
end;

procedure TForm1.Label15Click(Sender: TObject);
begin
  qw10 := true;
end;

procedure TForm1.Label16Click(Sender: TObject);
begin
  qw10 := false;
end;

procedure TForm1.SpeedButton10Click(Sender: TObject);
begin
  if qw10 = true then
    ball := ball + 1;
  Result.Caption := '�� �������� ����� �� ' + IntToStr(ball);
  PageControl1.ActivePageIndex := 10;
end;

procedure TForm1.SpeedButton1Click(Sender: TObject);
begin
  if qw1 = true then
    ball := ball + 1;
  PageControl1.ActivePageIndex := 1;
end;

procedure TForm1.SpeedButton2Click(Sender: TObject);
begin
  if qw2 = true then
    ball := ball + 1;
  PageControl1.ActivePageIndex := 2;
end;

procedure TForm1.SpeedButton3Click(Sender: TObject);
begin
  if RadioButton1.Checked = true then
    ball := ball + 1;
  PageControl1.ActivePageIndex := 3;
end;

procedure TForm1.SpeedButton4Click(Sender: TObject);
begin
  if checkbox1.Checked and checkbox4.Checked = true then
    ball := ball + 1;
  PageControl1.ActivePageIndex := 4;
end;

procedure TForm1.SpeedButton5Click(Sender: TObject);
begin
  if edit1.Text = '����' then
    ball := ball + 1;
  PageControl1.ActivePageIndex := 5;
end;

procedure TForm1.SpeedButton6Click(Sender: TObject);
begin
  if combobox1.Text = '������' then
    ball := ball + 1;
  PageControl1.ActivePageIndex := 6;
end;

procedure TForm1.SpeedButton7Click(Sender: TObject);
begin
  if TrackBar1.Position = 3 then
    ball := ball + 1;
  PageControl1.ActivePageIndex := 7;
end;

procedure TForm1.SpeedButton8Click(Sender: TObject);
begin
  if (Memo1.Lines[0] = '�����������')
   and (Memo1.Lines[1] = '�����������')
    and (Memo1.Lines[2] = '��������������')
     and (Memo1.Lines[3] = '����������') then
       ball := ball + 1;
  PageControl1.ActivePageIndex := 8;
end;

procedure TForm1.SpeedButton9Click(Sender: TObject);
begin
  if DateToStr(MonthCalendar1.Date) = '01.09.2017' then
    ball := ball + 1;
  PageControl1.ActivePageIndex := 9;
end;

procedure TForm1.TrackBar1Change(Sender: TObject);
begin
  if TrackBar1.Position = 0 then
    Shape1.Shape := stCircle;
  if TrackBar1.Position = 1 then
    Shape1.Shape := stEllipse;
  if TrackBar1.Position = 2 then
    Shape1.Shape := stRectangle;
  if TrackBar1.Position = 3 then
    Shape1.Shape := stRoundRect;
end;

end.
