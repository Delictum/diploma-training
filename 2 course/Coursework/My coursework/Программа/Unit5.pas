unit Unit5;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ComCtrls, Vcl.ExtCtrls,
  Vcl.Imaging.jpeg, Vcl.StdCtrls;

type
  TFormStart = class(TForm)
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Image1: TImage;
    Timer1: TTimer;
    ProgressBar1: TProgressBar;
    procedure Timer1Timer(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormStart: TFormStart;

implementation

{$R *.dfm}

uses Unit2;

procedure TFormStart.Timer1Timer(Sender: TObject);
begin
  ProgressBar1.Position := ProgressBar1.Position + 14;
  if ProgressBar1.Position >= 100 then
  begin
    FormStart.Hide;
    Form2.Show;
    Form2.Timer2.Enabled := true;
    Timer1.Enabled := false;
  end;

end;

end.
