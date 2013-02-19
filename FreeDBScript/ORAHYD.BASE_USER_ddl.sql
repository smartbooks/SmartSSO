-- Start of DDL Script for Table ORAHYD.BASE_USER
-- Generated 2012-6-15 下午 07:03:17 from ORAHYD@ORAHYD

CREATE TABLE base_user
    (userid                         NUMBER DEFAULT 0 NOT NULL,
    username                       VARCHAR2(50) NOT NULL,
    userpwd                        VARCHAR2(32) NOT NULL,
    parentid                       NUMBER DEFAULT 0,
    sex                            NUMBER DEFAULT 0,
    deptid                         NUMBER DEFAULT 0 NOT NULL,
    birthday                       DATE DEFAULT SYSDATE,
    degree                         VARCHAR2(50),
    face                           VARCHAR2(50),
    idnumber                       VARCHAR2(18),
    jobnumber                      VARCHAR2(50),
    photo                          VARCHAR2(200),
    prof                           VARCHAR2(50),
    remark                         VARCHAR2(50) DEFAULT '无',
    ststus                         NUMBER DEFAULT 0 NOT NULL,
    phone                          VARCHAR2(50) NOT NULL,
    realname                       VARCHAR2(50) NOT NULL,
    isline                         NUMBER DEFAULT 0)
  PCTFREE     10
  INITRANS    1
  MAXTRANS    255
  TABLESPACE  users
  STORAGE   (
    INITIAL     65536
    MINEXTENTS  1
    MAXEXTENTS  2147483645
  )
/





-- Constraints for BASE_USER

ALTER TABLE base_user
ADD CONSTRAINT pk_base_user PRIMARY KEY (userid)
USING INDEX
  PCTFREE     10
  INITRANS    2
  MAXTRANS    255
  TABLESPACE  users
  STORAGE   (
    INITIAL     65536
    MINEXTENTS  1
    MAXEXTENTS  2147483645
  )
/


-- Triggers for BASE_USER

CREATE OR REPLACE TRIGGER trg_base_user
 BEFORE
  INSERT
 ON base_user
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_USER.NEXTVAL
     INTO :NEW.USERID
     FROM DUAL;

EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;
/


-- Comments for BASE_USER

COMMENT ON TABLE base_user IS '用户信息表'
/
COMMENT ON COLUMN base_user.birthday IS '出生年月'
/
COMMENT ON COLUMN base_user.degree IS '学历'
/
COMMENT ON COLUMN base_user.deptid IS '用户所属部门'
/
COMMENT ON COLUMN base_user.face IS '政治面貌'
/
COMMENT ON COLUMN base_user.idnumber IS '身份证号码'
/
COMMENT ON COLUMN base_user.isline IS '是否在线（0：离线；1：在线）'
/
COMMENT ON COLUMN base_user.jobnumber IS '工作证号'
/
COMMENT ON COLUMN base_user.parentid IS '用户父ID编号（用于多个子账户）'
/
COMMENT ON COLUMN base_user.phone IS '联系电话'
/
COMMENT ON COLUMN base_user.photo IS '人员照片'
/
COMMENT ON COLUMN base_user.prof IS '专业'
/
COMMENT ON COLUMN base_user.realname IS '真实姓名'
/
COMMENT ON COLUMN base_user.remark IS '备注'
/
COMMENT ON COLUMN base_user.sex IS '性别（0：男 1：女）'
/
COMMENT ON COLUMN base_user.ststus IS '状态（0：正常，1：删除）'
/
COMMENT ON COLUMN base_user.userid IS '用户ID编号'
/
COMMENT ON COLUMN base_user.username IS '用户账号（登录使用）'
/
COMMENT ON COLUMN base_user.userpwd IS '用户密码（登录使用）'
/

-- End of DDL Script for Table ORAHYD.BASE_USER

