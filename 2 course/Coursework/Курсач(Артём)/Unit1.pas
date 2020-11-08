unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, jpeg, Vcl.ExtCtrls, Vcl.StdCtrls,
  Vcl.Imaging.pngimage;

type
  TFormLog = class(TForm)
    Image1: TImage;
    ImageAdminLog: TImage;
    ImageGuestLog: TImage;
    LabelAdminLog: TLabel;
    LabelGuestLog: TLabel;
    ImageFlyLog: TImage;
    EditPasLog: TEdit;
    procedure EditPasLogClick(Sender: TObject); //��� ������ ������� �� Edit-������ ������� �����
    procedure ImageAdminLogClick(Sender: TObject); //��� ������� �� ������ ������ ����������� ���� ����� ������ � ����������� ������������� ������, ���� ������� ����� �� ���������
    procedure ImageFlyLogClick(Sender: TObject);  //��������� ������ ��������� � (������) ������� � ���������, �������� - ����������� � �����
    procedure FormShow(Sender: TObject); //��� �������� ����� ���������� ����� ������� ����� ��� �������
    procedure ImageGuestLogClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction); //��������� ��������� ��� ����������� �������� ���������
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormLog: TFormLog;
  EditPasLogBoolean : Boolean;
  EditPasLogReWrite : integer;

implementation

{$R *.dfm}

uses Unit2, Unit10;

//��� ������ ������� �� Edit-������ ������� �����
procedure TFormLog.EditPasLogClick(Sender: TObject);
begin
  if EditPasLogBoolean <> true then  //���� ������� ����� �� ����
    EditPasLog.Text := '';           //������� �����
  EditPasLogBoolean := true;         //��������� ��� ������ ���� ������
  EditPasLog.PasswordChar := '*';
end;

procedure TFormLog.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  Form10.Close;
end;

//��� �������� ����� ���������� ����� ������� ����� ��� �������
procedure TFormLog.FormShow(Sender: TObject);
begin
  EditPasLogReWrite := 0;
end;

{��� ������� �� ������ ������ ����������� ���� ����� ������ � ����������� ������������� ������,
  ���� ������� ����� �� ���������}
procedure TFormLog.ImageAdminLogClick(Sender: TObject);
begin
  //���� �������� ������ = 4 ���� ������������
  if EditPasLogReWrite > 3 then
  begin
    ShowMessage('����� ������� ��������.');
    exit;
  end;
  //��������� ����������
  ImageFlyLog.Visible := true;
  EditPasLog.Visible := true;
end;

//��������� ������ ��������� � (������) ������� � ���������, �������� - ����������� � �����
procedure TFormLog.ImageFlyLogClick(Sender: TObject);
begin
  if EditPasLogReWrite = 4 then  //���� �������� ������ = 4 ...
    begin
      ImageFlyLog.Visible := false;  //��������
      EditPasLog.Visible := false;   // ����������
      EditPasLog.Text := '';         //  � ������� ������,
      exit;                          //   ����� ������������ � �����������
    end;
  //�������� �� ���� ������
  if (EditPasLog.Text = '������� ������') or (EditPasLog.Text = '') then
    begin
      ShowMessage('������� ������.'); //������
      exit;                          // � ����������� � ������
    end;

  //���� ������ ������ ������ � ������� < 4...
  if (EditPasLog.Text = 'AIR') and (EditPasLogReWrite < 4) then
    begin
      FormLog.Hide;   //�������� ���� �����������
      FormAir.Show;   //��������� ���������
      ImageFlyLog.Visible := false;   //�������� ����������
      EditPasLog.Visible := false;    // �
      EditPasLog.Text := '';          //  ������� ������
      EditPasLogReWrite := 0;         //�������� �������
      FormAir.MMAED.Visible := true;
      FormAir.ComboBox1.Visible := true;
    end
  else //�����...
    begin
      inc(EditPasLogReWrite); //�������� ���� + 1
      ShowMessage('�������� ������.'); //������ ���������� ������
    end;
end;

//��������� ��������� ��� ����������� �������� ���������, ��������������� �� � ����������� �������� ���� �����
procedure TFormLog.ImageGuestLogClick(Sender: TObject);
begin
  FormLog.Hide;  //����������� ���� �����������
  FormAir.Show;  //��������� ����� ���������
  EditPasLogReWrite := 0;  //�������� �������
  ImageFlyLog.Visible := false;   //�������� ����������
  EditPasLog.Visible := false;    // �
  EditPasLog.Text := '';          //  ������� ������
  FormAir.MMAED.Visible := false; //   ������� ���������
  FormAir.ComboBox1.Visible := false;
  {!}
end;

end.
