# mkdir /home/database/all_scripts;
# chmod -R 777 /home/database/all_scripts;
cp -a /home/database/dataset/*.sql /tmp/
cp -a /home/database/migrations/*.sql /tmp/
for i in `find /tmp/ -name "*.sql" | sort --version-sort`; do mysql -udocker -pdocker rest_with_asp_net_udemy < $i; done;
# rm -rf /home/database/all_scripts/;