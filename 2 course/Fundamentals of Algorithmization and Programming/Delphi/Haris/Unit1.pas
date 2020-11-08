unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ComCtrls, Vcl.ExtCtrls;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Edit2: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Button1: TButton;
    Button2: TButton;
    Timer1: TTimer;
    ProgressBar1: TProgressBar;
    Label4: TLabel;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;
type akk = record
  name : string;
  pass : string;
end;

var
  aks : array[1..10] of akk;
  i , indikator: integer;
  Form1: TForm1;

implementation

{$R *.dfm}

uses Unit2, Unit3, Unit4;

procedure TForm1.Button1Click(Sender: TObject);
Var aloha, us: boolean;
begin
Form2.PageControl1.ActivePageIndex := 0;
us:=true;
//indikator:=1;
if (edit1.Text='') or (edit2.Text='') then
begin
showMessage('Fill out the field');
us:=false;
//exit;
end;
aloha:=true;
aks[1].name := 'admin';
aks[1].pass := 'pass';
aks[2].name := 'a';
aks[2].pass := 'a';
aks[3].name := 'b';
aks[3].pass := 'b';
aks[4].name := 'c';
aks[4].pass := 'c';
for i := 1 to 10 do
begin
  if (aks[i].name = Edit1.Text) and (aks[i].pass = Edit2.Text) then
  begin
  timer1.Enabled:=True;
    aloha:=false;
  break;
  end
  else aloha:=true;
  end;
  if (aloha=true) and (us<>false) then
  showMessage('Wrong login or password');
end;


procedure TForm1.Button2Click(Sender: TObject);
begin
Form1.Hide;
Form3.Show;
end;

procedure TForm1.Timer1Timer(Sender: TObject);
begin
  if ProgressBar1.Position<100 then
  ProgressBar1.Position:=ProgressBar1.Position+random(100);
  if ProgressBar1.Position=100 then
  begin
  Form1.Hide;
  Form2.Show;
  form1.Timer1.Enabled:=false;
  end;
end;

end.
