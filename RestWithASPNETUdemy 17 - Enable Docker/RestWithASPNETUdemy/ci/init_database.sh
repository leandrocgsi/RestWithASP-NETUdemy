mkdir /home/database/all_scripts;
chmod 777 /home/database/all_scripts;
cp -a /home/database/dataset/. /home/database/all_scripts/;
cp -a /home/database/migrations/. /home/database/all_scripts/;
for i in `find /home/database/ -name "*.sql" | sort --version-sort`; do mysql -udocker -pdocker rest_with_asp_net_udemy < $i; done;
rm -rf /home/database/all_scripts/;