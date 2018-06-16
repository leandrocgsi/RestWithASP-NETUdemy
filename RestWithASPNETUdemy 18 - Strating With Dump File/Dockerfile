FROM mysql:5.7.22
EXPOSE 3306
# COPY ./RestWithASPNETUdemy/db/migrations/ /docker-entrypoint-initdb.d/
# COPY ./RestWithASPNETUdemy/db/dataset/ /docker-entrypoint-initdb.d/
COPY DBBackup/backup.sql /docker-entrypoint-initdb.d/backup.sql
# COPY RestWithASPNETUdemy/db/migrations/V1_0_1__Create_Table_Persons.sql /docker-entrypoint-initdb.d/V1_0_1__Create_Table_Persons.sql
# COPY RestWithASPNETUdemy/db/migrations/V1_0_2__Alter_Table_Persons.sql /docker-entrypoint-initdb.d/V1_0_2__Alter_Table_Persons.sql
# COPY RestWithASPNETUdemy/db/migrations/V1_0_3__Create_table_books.sql /docker-entrypoint-initdb.d/V1_0_3__Create_table_books.sql
# COPY RestWithASPNETUdemy/db/dataset/V1_0_4__Insert_data_in_books.sql /docker-entrypoint-initdb.d/V1_0_4__Insert_data_in_books.sql
# COPY RestWithASPNETUdemy/db/dataset/V1_0_5__Insert_data_in_persons.sql /docker-entrypoint-initdb.d/V1_0_5__Insert_data_in_persons.sql
# COPY RestWithASPNETUdemy/db/migrations/V1_0_6__Drop_table_books.sql /docker-entrypoint-initdb.d/V1_0_6__Drop_table_books.sql
# COPY RestWithASPNETUdemy/db/migrations/V1_0_7__Recreate_table_books.sql /docker-entrypoint-initdb.d/V1_0_7__Recreate_table_books.sql
# COPY RestWithASPNETUdemy/db/dataset/V1_0_8__Reinsert_data_in_books.sql /docker-entrypoint-initdb.d/V1_0_8__Reinsert_data_in_books.sql
# COPY RestWithASPNETUdemy/db/migrations/V1_0_9__Create_table_users.sql /docker-entrypoint-initdb.d/V1_0_9__Create_table_users.sql
# COPY RestWithASPNETUdemy/db/dataset/V1_0_10__Insert_data_in_users.sql /docker-entrypoint-initdb.d/V1_0_10__Insert_data_in_users.sql
# COPY RestWithASPNETUdemy/db/dataset/V1_0_11__Insert_data_in_persons.sql /docker-entrypoint-initdb.d/V1_0_11__Insert_data_in_persons.sql